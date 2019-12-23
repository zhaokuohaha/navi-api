from . import napi
from navi.utils import json_resp
import navi.nservice.home_service as h_service
from ..models import Tab, Link
from flask import request,jsonify

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
def create_tab():
    tab = request.json
    id = h_service.add_tab(tab)
    return json_resp(id)

@napi.route('/api/tab/<tabid>', methods=['DELETE'])
def delete_tab(tabid: int):
    h_service.delete_tab(tabid)
    return json_resp()

@napi.route('/api/link', methods=['POST'])
def create_link():
    link = request.json
    h_service.add_link(link)
    return json_resp()

@napi.route('/api/link/<linkid>', methods=['DELETE'])
def delate_link(linkid: int):
    h_service.delete_link(linkid)
    return json_resp()


@napi.route('/')
def test():
    return 'Hello Word'
