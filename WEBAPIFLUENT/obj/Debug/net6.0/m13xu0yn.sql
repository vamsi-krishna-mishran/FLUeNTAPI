CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `Product` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Varient` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `PId` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Varient_Product_PId` FOREIGN KEY (`PId`) REFERENCES `Product` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Board` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `VId` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Board_Varient_VId` FOREIGN KEY (`VId`) REFERENCES `Varient` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Rivision` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `BId` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Rivision_Board_BId` FOREIGN KEY (`BId`) REFERENCES `Board` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Identity` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Description` longtext NOT NULL,
    `RId` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Identity_Rivision_RId` FOREIGN KEY (`RId`) REFERENCES `Rivision` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `BareBoardDetails` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `ImageName` longtext NOT NULL,
    `IId` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_BareBoardDetails_Identity_IId` FOREIGN KEY (`IId`) REFERENCES `Identity` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_BareBoardDetails_IId` ON `BareBoardDetails` (`IId`);

CREATE INDEX `IX_Board_VId` ON `Board` (`VId`);

CREATE INDEX `IX_Identity_RId` ON `Identity` (`RId`);

CREATE INDEX `IX_Rivision_BId` ON `Rivision` (`BId`);

CREATE INDEX `IX_Varient_PId` ON `Varient` (`PId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230613072934_First', '7.0.5');

COMMIT;

