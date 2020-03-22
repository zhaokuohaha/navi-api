import datetime
import os
from peewee import *

from config import config

cfg = config[os.getenv('FLASK_ENV') or 'default']
db = MySQLDatabase(host=cfg.DB_HOST,
                   user=cfg.DB_USER,
                   passwd=cfg.DB_PASSWD,
                   database=cfg.DB_DATABASE)


class BaseMode(Model):
    # class Meta:
    #     database = db
    pass


class User(BaseMode):
    id = IntegerField()
    name = CharField()
    pwd = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)

    class Meta:
        database = db
        table_name = 'nuser'


class Tab(BaseMode):
    id = IntegerField()
    userid = IntegerField()
    title = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)

    class Meta:
        database = db
        table_name = 'ntab'


class Link(BaseMode):
    id = IntegerField()
    title = CharField()
    url = TextField()
    icon = TextField()
    bgcolor = CharField()
    createtime = DateTimeField(default=datetime.datetime.now)
    deletetime = DateTimeField(default=None)
    tabid = ForeignKeyField(Tab, column_name="tabid", backref="links")

    class Meta:
        database = db
        table_name = 'nlink'
