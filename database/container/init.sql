CREATE DATABASE IF NOT EXISTS `kwtc_dbo`;

GRANT ALL ON *.* TO 'root'@'%';

FLUSH PRIVILEGES;

USE kwtc_dbo;

CREATE TABLE `Report`
(
    `Id`        char(36) CHARACTER SET ascii NOT NULL,
    `AppId`     varchar(512)                 NOT NULL,
    `UserId`    char(36) CHARACTER SET ascii NOT NULL,
    `CreatedAt` datetime(6)                  NOT NULL,
    `UpdatedAt` datetime(6) DEFAULT NULL,
    PRIMARY KEY (`Id`),
    KEY `IX_Report_UserId` (`UserId`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `User`
(
    `Id`        char(36) CHARACTER SET ascii NOT NULL,
    `Name`      varchar(512)                 NOT NULL,
    `CreatedAt` datetime(6)                  NOT NULL,
    `UpdatedAt` datetime(6) DEFAULT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

ALTER TABLE `Report`
    ADD CONSTRAINT `FK_Report_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE;

INSERT INTO User (Id, Name, CreatedAt) VALUES ('BA549233-4C00-4889-9CD7-E1134527E4D1', 'System', NOW());

COMMIT;