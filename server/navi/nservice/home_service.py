from navi.models import *
from navi.utils import *
from navi.nservice.tools import *


def get_links(userid):
    query = Tab.select(Link, Tab.title.alias('tabtitle')) \
        .join(Link, JOIN.LEFT_OUTER) \
        .where((Tab.userid == userid) & (Link.deletetime.is_null())) \
        .dicts()

    return list(query)


def find_user(username):
    try:
        query = User.get((User.name == username) & (User.deletetime is not None))
        return query
    except Exception:
        return False

def add_tab(tab: dict, userid):
    tab['createtime'] = datetime.datetime.now()
    tab['userid'] = userid
    Tab.insert(tab).execute()


def delete_tab(tabid):
    Tab.update({Tab.deletetime: datetime.datetime.now()}) \
        .where(Tab.id == tabid) \
        .execute()


def add_link(link: dict):
    link['id'] = None
    link['createtime'] = datetime.datetime.now()
    if not ('icon' in link.keys() and link['icon']):
        (icon, bgcolor) = get_icon(link['url'])
        link['icon'] = icon
        link['bgcolor'] = bgcolor
    if not ('bgcolor' in link.keys() and link['bgcolor']):
        link['bgcolor'] = get_bgcolor(link['icon'])
    Link.insert(link).execute()


def update_link(link: dict):
    if 'id' not in link:
        return
    curlink = Link.get_by_id(link['id'])
    curlink.title = link['title']
    curlink.url = link['url']
    if 'bgcolor' in link and link['bgcolor']:
        curlink.bgcolor = link['bgcolor']
    if 'icon' in link and link['icon']:
        curlink.icon = link['icon']
    curlink.save()


def delete_link(id):
    Link.update({Link.deletetime: datetime.datetime.now()}) \
        .where(Link.id == id) \
        .execute()


def login(user: str, pwd: str):
    u = find_user(user)
    if u.pwd == pwd:
        return u


def identity(playload):
    user_id = playload['identity']
    return User.get_by_id(user_id)


def add_user(user):
    if not (user and user['name']):
        return '请输入正确的用户路径'
    if (find_user(user['name'])):
        return '改名吧， 被用了！'

    user['createtime'] = datetime.datetime.now()
    User.insert(user).execute()
    return None