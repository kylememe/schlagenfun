import os

from flask import Flask


def create_app(test_config=None):
    """Create and configure an instance of the Flask application."""
    app = Flask(__name__, instance_relative_config=True)
    app.config.from_mapping(
        # a default secret that should be overridden by instance config
        SECRET_KEY="dev",
        # store the database in the instance folder
        DATABASE=os.path.join(app.instance_path, "schlagenfun.sqlite"),
    )

    if test_config is None:
        # load the instance con
        app.config.from_pyfile("config.py", silent=True)
    else:
        # load the test config if passed in
        app.config.update(test_config)

    # ensure the instance folder exists
    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    @app.route("/hello")
    def hello():
        return "Hello, World!"    

    from . import db
    db.init_app(app)

    #initialize database if it hasn't been yet. Should add check in here to make sure we want to do this from config. 
    with app.app_context():
        instance = db.get_db()
        usertable = instance.execute("SELECT name FROM sqlite_master WHERE type='table' AND name='user';").fetchone()
        if usertable is None:
            db.init_db()


    from . import auth
    app.register_blueprint(auth.bp)

    from . import blog
    app.register_blueprint(blog.bp)
    app.add_url_rule('/', endpoint='index')

    return app

