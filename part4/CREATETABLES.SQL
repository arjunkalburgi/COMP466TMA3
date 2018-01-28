DROP TABLE users; 
DROP TABLE cartitems; 
DROP TABLE cartcomps; 
DROP TABLE products; 
DROP TABLE computers; 

CREATE TABLE users (
    id char(36) NOT NULL,
    name varchar(100) NOT NULL,
    password varchar(100) NOT NULL,
    CONSTRAINT PK_users PRIMARY KEY (id)
);

CREATE TABLE cartitems (
    id char(36) NOT NULL,
    description varchar(700) NOT NULL,
    image varchar(100) NOT NULL,
    name varchar(50) NOT NULL,
    price float NOT NULL,
    CONSTRAINT PK_cartitems PRIMARY KEY (id)
);


CREATE TABLE cartcomps (
    id char(36) NOT NULL,
    CPUid char(36) NOT NULL,
    Displayid char(36) NOT NULL,
    HDid char(36) NOT NULL,
    OSid char(36) NOT NULL,
    RAMid char(36) NOT NULL,
    SoundCardid char(36) NOT NULL,
    description varchar(700) NOT NULL,
    image varchar(100) NOT NULL,
    name varchar(50) NOT NULL,
    price float NOT NULL,
    CONSTRAINT PK_cartcomps PRIMARY KEY (id)
);

CREATE TABLE products (
    id char(36) NOT NULL,
    description varchar(700) NOT NULL,
    image varchar(100) NOT NULL,
    name varchar(50) NOT NULL,
    price float NOT NULL,
    CONSTRAINT PK_products PRIMARY KEY (id)
);


CREATE TABLE computers (
    id char(36) NOT NULL,
    CPUid char(36) NOT NULL,
    Displayid char(36) NOT NULL,
    HDid char(36) NOT NULL,
    OSid char(36) NOT NULL,
    RAMid char(36) NOT NULL,
    SoundCardid char(36) NOT NULL,
    description varchar(700) NOT NULL,
    image varchar(100) NOT NULL,
    name varchar(50) NOT NULL,
    price float NOT NULL,
    CONSTRAINT PK_cartcomps PRIMARY KEY (id),
    CONSTRAINT FK_ramid FOREIGN KEY (RAMid) REFERENCES products (id), 
    CONSTRAINT FK_hdid FOREIGN KEY (HDid) REFERENCES products (id), 
    CONSTRAINT FK_cpuid FOREIGN KEY (CPUid) REFERENCES products (id), 
    CONSTRAINT FK_soundcardid FOREIGN KEY (SoundCardid) REFERENCES products (id), 
    CONSTRAINT FK_displayid FOREIGN KEY (Displayid) REFERENCES products (id), 
    CONSTRAINT FK_osid FOREIGN KEY (OSid) REFERENCES products (id)
);
