#!/usr/bin/env python3
import os
from navi import create_app
from flask_script import Manager, Server

app = create_app(os.getenv('FLASK_ENV') or 'default')
manager = Manager(app)

server = Server(host="0.0.0.0", port=5002)
manager.add_command("runserver", server)


@manager.command
def test():
    import unittest
    tests = unittest.TestLoader().discover('tests')
    unittest.TextTestRunner(verbosity=2).run(tests)


if __name__ == '__main__':
    manager.run()
