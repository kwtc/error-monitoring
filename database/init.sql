CREATE DATABASE IF NOT EXISTS `kwtc_error_monitoring_dbo`;

GRANT ALL ON *.* TO 'root'@'%';

FLUSH PRIVILEGES;

USE kwtc_error_monitoring_dbo;

CREATE TABLE `Report`
(
    `Id`        char(36)             CHARACTER SET ascii NOT NULL,
    `ClientId`  char(36)             CHARACTER SET ascii NOT NULL,
    `CreatedAt` datetime       DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (`Id`),
    KEY `IX_Report_ClientId` (`ClientId`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Client`
(
    `Id`        char(36)             CHARACTER SET ascii NOT NULL,
    `ApiKey`    char(36)             CHARACTER SET ascii NOT NULL,
    `CreatedAt` datetime       DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Event`
(
    `Id`        char(36)             CHARACTER SET ascii NOT NULL,
    `ReportId`  char(36)             CHARACTER SET ascii NOT NULL,
    `AppIdentifier` varchar(512)                         NOT NULL,
    `ExceptionType` varchar(512)                         NOT NULL,
    `ExceptionMessage`  text                             NOT NULL,
    `Severity`  int                                      NOT NULL,
    `IsHandled` bit                                      NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Exception`
(
    `Id`        int                       AUTO_INCREMENT NOT NULL,
    `EventId`   char(36)             CHARACTER SET ascii NOT NULL,
    `Type`      varchar(512)                             NOT NULL,
    `Message`   text                                     NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Trace`
(
    `Id`          int                       AUTO_INCREMENT NOT NULL,
    `ExceptionId` int                                      NOT NULL,
    `File`        varchar(512)                             NOT NULL,
    `Method`      varchar(512)                             NOT NULL,
    `LineNumber`  int                                      NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

ALTER TABLE `Report`
    ADD CONSTRAINT `FK_Report_Client_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Client` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Event`
    ADD CONSTRAINT `FK_Event_Report_ReportId` FOREIGN KEY (`ReportId`) REFERENCES `Report` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Exception`
    ADD CONSTRAINT `FK_Exception_Event_EventId` FOREIGN KEY (`EventId`) REFERENCES `Event` (`Id`) ON DELETE CASCADE;

ALTER TABLE `Trace`
    ADD CONSTRAINT `FK_Trace_Exception_ExceptionId` FOREIGN KEY (`ExceptionId`) REFERENCES `Exception` (`Id`) ON DELETE CASCADE;

INSERT INTO Client (Id, ApiKey) VALUES ('CA449231-4C00-4889-9CD7-E1734527E4D1', 'BA549233-4C00-4889-9CD7-E1134527E4D1');

COMMIT;