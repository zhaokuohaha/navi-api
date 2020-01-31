from . import napi
from navi.utils import json_resp
import navi.nservice.home_service as h_service
from ..models import Tab, Link
from flask import request,jsonify
from flask_jwt import jwt_required, current_identity

@napi.route('/api/data', methods=['GET'])
@napi.route('/api/data/<username>', methods=['GET'])
def get_data(username: str=None):
    if username is None:
        return json_resp(status=400, errinfo='未实现')
    if(username is None):
        return json_resp(status=404, errinfo='未找到路径')
    user = h_service.find_user(username)
    data = h_service.get_links(user.id)
    return json_resp(data)

@napi.route('/api/tab', methods=['POST'])
@jwt_required()
def create_tab():
    userid = current_identity.id
    tab = request.json
    id = h_service.add_tab(tab, userid)
    return json_resp(id)

@napi.route('/api/tab/<tabid>', methods=['DELETE'])
@jwt_required()
def delete_tab(tabid: int):
    h_service.delete_tab(tabid)
    return json_resp()

@napi.route('/api/link', methods=['POST'])
@jwt_required()
def create_link():
    link = request.json
    h_service.add_link(link)
    return json_resp()


@napi.route('/api/link', methods=['PATCH'])
@jwt_required()
def update_link():
    link = request.json
    h_service.update_link(link)
    return json_resp()

@napi.route('/api/link/<linkid>', methods=['DELETE'])
@jwt_required()
def delate_link(linkid: int):
    h_service.delete_link(linkid)
    return json_resp()


@napi.route('/api/user', methods=['POST'])
def add_user():
    user  = request.json
    msg = h_service.add_user(user)
    if msg:
        return json_resp(status=400, jobj=msg)
    return json_resp()


@napi.route('/')
@jwt_required()
def test():
    return '%s' % current_identity
