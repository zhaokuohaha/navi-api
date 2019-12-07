CREATE TABLE nuser(
    id INT4 PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name VARCHAR(64) NOT NULL,
    pwd VARCHAR(64) NOT NULL,
    createtime DATETIME,
    deletetime DATETIME DEFAULT NULL
);

CREATE TABLE ntab(
    id INT4 PRIMARY KEY AUTO_INCREMENT NOT NULL,
    userid INT4 NOT NULL,
    title VARCHAR(128),
    createtime DATETIME,
    deletetime DATETIME DEFAULT NULL
);

CREATE TABLE nlink (
    id INT4 PRIMARY KEY AUTO_INCREMENT NOT NULL,
    tabid INT4 NOT NULL,
    title VARCHAR(64) NOT NULL,
    url TEXT NOT NULL,
    icon TEXT,
    bgcolor VARCHAR(64),
    createtime DATETIME,
    deletetime DATETIME DEFAULT NULL
);

INSERT INTO nuser (name, pwd, createtime) VALUES ('me', 'fcz', date('now'))