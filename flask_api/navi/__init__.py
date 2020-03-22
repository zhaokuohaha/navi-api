import os
from datetime import timedelta
from flask import Flask
from flask_jwt import JWT
from config import config
from flask_cors import CORS
from navi.nservice.home_service import login, identity


def create_app(cfg):
    app = Flask(__name__)
    CORS(app)
    app.config.from_object(config[cfg])
    config[cfg].init_app(app)
    app.config['SECRET_KEY'] = os.getenv('SECRET_KEY') or  'super-secret'
    app.config['JWT_EXPIRATION_DELTA'] = timedelta(hours=300)
    app.config['JWT_AUTH_URL_RULE'] = '/api/auth'
    jwt = JWT(app, login, identity)

    # todo 如果文件夹命名位 api 这里不能正确引用, 不知为何
    from .napi import napi as napi_blueprint
    app.register_blueprint(napi_blueprint)

    return app
