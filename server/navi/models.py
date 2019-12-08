import os
import peewee
import datetime
from config import config
from peewee import MySQLDatabase, Model, CharField, IntegerField, DateTimeField, TextField, IntegerField

cfg = config[os.getenv('FLASK_ENV') or 'default']
db = MySQLDatabase(host=cfg.DB_HOST, user=cfg.DB_USER,
                   passwd=cfg.DB_PASSWD, database=cfg.DB_DATABASE)


class BaseMode(Model):
    class Meta:
        database = db


class nuser(BaseMode):
    id = IntegerField()
    name = CharField()
    pwd = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)


class ntab(BaseMode):
    id = IntegerField()
    userid = IntegerField()
    title = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)


class nlink(BaseMode):
    id = IntegerField()
    tabid = IntegerField()
    title = CharField()
    url = TextField()
    icon = TextField()
    bgcolor = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)
