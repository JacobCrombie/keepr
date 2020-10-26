-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );


-- CREATE TABLE keeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   img VARCHAR(255) NOT NULL,
--   views INT NOT NULL,
--   keeps INT NOT NULL,
--   shares INT,
--   PRIMARY KEY (id)
-- );

-- SELECT * FROM profiles;
/* 
        SELECT
        keep.*,
        prof.*
        FROM keeps keep
        JOIN profiles prof ON keep.creatorId = prof.id
        WHERE keep.creatorId = "296fe478-a97e-4279-8b2f-7af5d6c976a6"; */
/* 
        SELECT * FROM keeps */

-- CREATE TABLE vaults
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   isprivate TINYINT,
--   PRIMARY KEY (id)
-- );

-- TRUNCATE TABLE vaults;

-- CREATE TABLE vaultkeeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   keepId INT,
--   vaultId INT,
--   PRIMARY KEY (id),

--   FOREIGN KEY (keepId)
--     REFERENCES keeps (id)
--     ON DELETE CASCADE,
--   FOREIGN KEY (vaultId)
--     REFERENCES vaults (id)
--     ON DELETE CASCADE
-- );
