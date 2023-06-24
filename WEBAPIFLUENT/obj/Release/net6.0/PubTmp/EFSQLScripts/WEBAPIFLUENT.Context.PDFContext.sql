CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `products` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `varients` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `PId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_varients_products_PId` FOREIGN KEY (`PId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `boards` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `VId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_boards_varients_VId` FOREIGN KEY (`VId`) REFERENCES `varients` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `rivisions` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `BId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_rivisions_boards_BId` FOREIGN KEY (`BId`) REFERENCES `boards` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `identity` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Description` longtext NOT NULL,
        `RId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_identity_rivisions_RId` FOREIGN KEY (`RId`) REFERENCES `rivisions` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE TABLE `bareboards` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `ImageName` longtext NOT NULL,
        `IId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_bareboards_identity_IId` FOREIGN KEY (`IId`) REFERENCES `identity` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE INDEX `IX_bareboards_IId` ON `bareboards` (`IId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE INDEX `IX_boards_VId` ON `boards` (`VId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE INDEX `IX_identity_RId` ON `identity` (`RId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE INDEX `IX_rivisions_BId` ON `rivisions` (`BId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    CREATE INDEX `IX_varients_PId` ON `varients` (`PId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615045502_firstmigration')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230615045502_firstmigration', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615091657_addeddesc')
BEGIN
    ALTER TABLE `bareboards` ADD `Description` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615091657_addeddesc')
BEGIN
    ALTER TABLE `bareboards` ADD `ImageData` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615091657_addeddesc')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230615091657_addeddesc', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615092915_addedAssembledboarddetails')
BEGIN
    CREATE TABLE `assembledBoards` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Type` longtext NOT NULL,
        `Status` int NOT NULL,
        `Remark` int NOT NULL,
        `IId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_assembledBoards_identity_IId` FOREIGN KEY (`IId`) REFERENCES `identity` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615092915_addedAssembledboarddetails')
BEGIN
    CREATE INDEX `IX_assembledBoards_IId` ON `assembledBoards` (`IId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615092915_addedAssembledboarddetails')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230615092915_addedAssembledboarddetails', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615101924_addedHeadingandsubheading')
BEGIN
    CREATE TABLE `headings` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `IId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_headings_identity_IId` FOREIGN KEY (`IId`) REFERENCES `identity` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615101924_addedHeadingandsubheading')
BEGIN
    CREATE TABLE `subheading` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `HId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_subheading_headings_HId` FOREIGN KEY (`HId`) REFERENCES `headings` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615101924_addedHeadingandsubheading')
BEGIN
    CREATE INDEX `IX_headings_IId` ON `headings` (`IId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615101924_addedHeadingandsubheading')
BEGIN
    CREATE INDEX `IX_subheading_HId` ON `subheading` (`HId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230615101924_addedHeadingandsubheading')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230615101924_addedHeadingandsubheading', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616051019_AddedUserTable')
BEGIN
    CREATE TABLE `users` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Email` longtext NOT NULL,
        `Password` longtext NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616051019_AddedUserTable')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230616051019_AddedUserTable', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616055517_AddedUniquekeyconstraint')
BEGIN
    ALTER TABLE `users` MODIFY `Name` varchar(255) NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616055517_AddedUniquekeyconstraint')
BEGIN
    ALTER TABLE `users` MODIFY `Email` varchar(255) NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616055517_AddedUniquekeyconstraint')
BEGIN
    CREATE UNIQUE INDEX `IX_users_Email` ON `users` (`Email`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616055517_AddedUniquekeyconstraint')
BEGIN
    CREATE UNIQUE INDEX `IX_users_Name` ON `users` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230616055517_AddedUniquekeyconstraint')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230616055517_AddedUniquekeyconstraint', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623054125_modifiedremarkfield')
BEGIN
    ALTER TABLE `assembledBoards` MODIFY `Remark` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623054125_modifiedremarkfield')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230623054125_modifiedremarkfield', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623063101_addedboardtype')
BEGIN
    ALTER TABLE `bareboards` ADD `BoardType` int NOT NULL DEFAULT 0;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623063101_addedboardtype')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230623063101_addedboardtype', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623105548_addedpoweruptest')
BEGIN
    CREATE TABLE `poweruptests` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Ref` longtext NOT NULL,
        `PUT` int NOT NULL,
        `Exp` longtext NOT NULL,
        `Mes` longtext NOT NULL,
        `IId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_poweruptests_identity_IId` FOREIGN KEY (`IId`) REFERENCES `identity` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623105548_addedpoweruptest')
BEGIN
    CREATE INDEX `IX_poweruptests_IId` ON `poweruptests` (`IId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623105548_addedpoweruptest')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230623105548_addedpoweruptest', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623111606_changedPUTbacktostring')
BEGIN
    ALTER TABLE `poweruptests` MODIFY `PUT` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623111606_changedPUTbacktostring')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230623111606_changedPUTbacktostring', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623125943_addedIsEO')
BEGIN
    ALTER TABLE `subheading` ADD `IsEo` tinyint(1) NOT NULL DEFAULT FALSE;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230623125943_addedIsEO')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230623125943_addedIsEO', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624064802_addedremarkfieldinheadingandsubheading')
BEGIN
    ALTER TABLE `subheading` ADD `Remark` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624064802_addedremarkfieldinheadingandsubheading')
BEGIN
    ALTER TABLE `headings` ADD `Remark` longtext NOT NULL;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624064802_addedremarkfieldinheadingandsubheading')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230624064802_addedremarkfieldinheadingandsubheading', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624072727_addedsubheadingimages')
BEGIN
    CREATE TABLE `subheadingimages` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `ImageData` longtext NOT NULL,
        `SHId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_subheadingimages_subheading_SHId` FOREIGN KEY (`SHId`) REFERENCES `subheading` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624072727_addedsubheadingimages')
BEGIN
    CREATE INDEX `IX_subheadingimages_SHId` ON `subheadingimages` (`SHId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624072727_addedsubheadingimages')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230624072727_addedsubheadingimages', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624074542_droppedisEo')
BEGIN
    ALTER TABLE `subheading` DROP COLUMN `IsEo`;
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624074542_droppedisEo')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230624074542_droppedisEo', '7.0.5');
END;

COMMIT;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624093711_AddedXlsandcascadedeltes')
BEGIN
    CREATE TABLE `xLTamplates` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `SHId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_xLTamplates_subheading_SHId` FOREIGN KEY (`SHId`) REFERENCES `subheading` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624093711_AddedXlsandcascadedeltes')
BEGIN
    CREATE TABLE `xLSheets` (
        `Id` bigint NOT NULL AUTO_INCREMENT,
        `Col1` longtext NOT NULL,
        `Col2` longtext NOT NULL,
        `Col3` longtext NOT NULL,
        `Col4` longtext NOT NULL,
        `XId` bigint NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_xLSheets_xLTamplates_XId` FOREIGN KEY (`XId`) REFERENCES `xLTamplates` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624093711_AddedXlsandcascadedeltes')
BEGIN
    CREATE INDEX `IX_xLSheets_XId` ON `xLSheets` (`XId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624093711_AddedXlsandcascadedeltes')
BEGIN
    CREATE INDEX `IX_xLTamplates_SHId` ON `xLTamplates` (`SHId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230624093711_AddedXlsandcascadedeltes')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230624093711_AddedXlsandcascadedeltes', '7.0.5');
END;

COMMIT;

