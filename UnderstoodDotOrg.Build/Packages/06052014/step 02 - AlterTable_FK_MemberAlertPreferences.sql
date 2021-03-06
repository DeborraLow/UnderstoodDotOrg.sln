/*
   Thursday, June 05, 20141:22:53 PM
   User: understood_org
   Server: 162.209.22.3
   Database: Understood.org.DEV.membership
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Members SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Members', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Members', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Members', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberAlertPreferences ADD CONSTRAINT
	FK_MemberAlertPreferences_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberAlertPreferences SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MemberAlertPreferences', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MemberAlertPreferences', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MemberAlertPreferences', 'Object', 'CONTROL') as Contr_Per 