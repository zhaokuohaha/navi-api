from flask import Response, jsonify


def json_resp(jobj=None, status=200, errinfo=None):
    if status >= 200 and status < 300:
        return jsonify(jobj)
    else:
        return Response('{"errinfo":"%s"}' % (errinfo,), mimetype='application/json', status=status)
