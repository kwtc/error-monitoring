CREATE DATABASE IF NOT EXISTS `kwtc_error_monitoring_dbo`;

GRANT ALL ON *.* TO 'root'@'%';

FLUSH PRIVILEGES;

USE kwtc_error_monitoring_dbo;

CREATE TABLE `Report`
(
    `Id`        binary(16) DEFAULT (uuid_to_bin(uuid())) NOT NULL,
    `AppId`     varchar(512)                                 NULL,
    `ClientId`  binary(16)                               NOT NULL,
    `CreatedAt` datetime       DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (`Id`),
    KEY `IX_Report_ClientId` (`ClientId`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Client`
(
    `Id`        binary(16) DEFAULT (uuid_to_bin(uuid())) NOT NULL,
    `ApiKey`    binary(16)                               NOT NULL,
    `CreatedAt` datetime       DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Event`
(
    `Id`        binary(16) DEFAULT (uuid_to_bin(uuid())) NOT NULL,
    `ReportId`  binary(16)                               NOT NULL,
    `Severity`  int                                      NOT NULL,
    `IsHandled` bit                                      NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Exception`
(
    `Id`        binary(16) DEFAULT (uuid_to_bin(uuid())) NOT NULL,
    `EventId`   binary(16)                               NOT NULL,
    `Type`      varchar(512)                             NOT NULL,
    `Message`   text                                     NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4;

CREATE TABLE `Trace`
(
    `Id`          binary(16) DEFAULT (uuid_to_bin(uuid())) NOT NULL,
    `ExceptionId` binary(16)                               NOT NULL,
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

INSERT INTO Client (ApiKey) VALUES ('BA549233-4C00-4889-9CD7-E1134527E4D1');

COMMIT;