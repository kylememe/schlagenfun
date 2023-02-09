from schlagen_web.extensions import db
from sqlalchemy import ForeignKey
from sqlalchemy.orm import relationship
from sqlalchemy.sql import func

class Post(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    author_id = db.Column(db.Integer, ForeignKey("user.id"))
    created = db.Column(db.DateTime, server_default=func.now())
    title = db.Column(db.Text)
    body = db.Column(db.Text)

    # Relationships
    user = relationship("User")

    def __repr__(self):
        return f'<Post "{self.title}">'



