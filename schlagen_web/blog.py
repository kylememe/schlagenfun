from flask import (
    Blueprint, flash, g, redirect, render_template, request, url_for
)
from werkzeug.exceptions import abort

from sqlalchemy import select

from schlagen_web.auth import login_required
from schlagen_web.extensions import db
from schlagen_web.models.post import Post
from schlagen_web.models.user import User

bp = Blueprint('blog', __name__)

def get_post(id, check_author=True):
    
    post = Post.query.get(id)    

    if post is None:
        abort(404, f"Post id {id} doesn't exist.")

    if check_author and post.author_id != g.user.id:
        abort(403)

    return post


@bp.route('/')
def index():

    posts = db.session.scalars(select(Post, User.username).order_by(Post.created))

    return render_template('blog/index.html', posts=posts)

@bp.route('/create', methods=('GET', 'POST'))
@login_required
def create():
    if request.method == 'POST':
        title = request.form['title']
        body = request.form['body']
        error = None

        if not title:
            error = 'Title is required.'

        if error is not None:
            flash(error)
        else:
            post = Post(title = title, body = body, author_id = g.user.id)
            db.session.add(post)
            db.session.commit()
            
            return redirect(url_for('blog.index'))

    return render_template('blog/create.html')

@bp.route('/<int:id>/update', methods=('GET', 'POST'))
@login_required
def update(id):
    post = get_post(id)

    if request.method == 'POST':
        title = request.form['title']
        body = request.form['body']
        error = None

        if not title:
            error = 'Title is required.'

        if error is not None:
            flash(error)
        else:
            post.title = title
            post.body = body
            post.author_id = g.user.id
            db.session.add(post)
            db.session.commit()
            
            return redirect(url_for('blog.index'))

    return render_template('blog/update.html', post=post)

@bp.route('/<int:id>/delete', methods=('POST',))
@login_required
def delete(id):
    post = get_post(id)
    db.session.delete(post)
    db.session.commit()
    
    return redirect(url_for('blog.index'))