from flask import Flask
from config import config
# from flask_jwt import JWT
from navi.auth import *


def create_app(cfg):
    app = Flask(__name__)
    app.config.from_object(config[cfg])
    config[cfg].init_app(app)
    # jwt = JWT(app, authenticate, identity)

    # todo 如果文件夹命名位 api 这里不能正确引用, 不知为何
    from .napi import napi as napi_blueprint
    app.register_blueprint(napi_blueprint)

    return app
