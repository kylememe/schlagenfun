from schlagen_web.extensions import db

class User(db.Model):
    id = db.Column(db.Integer, primary_key=True, autoincrement=True)
    username = db.Column(db.Text, unique=True)
    password = db.Column(db.Text)

    # Relationships
    posts = db.relationship('Post', back_populates="user")

    def __repr__(self):
        return f'<User {self.username}>'
    