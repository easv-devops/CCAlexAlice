CREATE TABLE history
(
    id     INT AUTO_INCREMENT PRIMARY KEY,
    date   DATE DEFAULT CURDATE(),
    source TEXT  NOT NULL,
    target TEXT  NOT NULL,
    value  FLOAT NOT NULL,
    result FLOAT NOT NULL
);