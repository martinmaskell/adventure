/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\ReferenceData\LocationData.Direction.sql
:r .\ReferenceData\LookupData.Action.sql
:r .\ReferenceData\LookupData.CommandType.sql
:r .\ReferenceData\LookupData.DependencyType.sql
:r .\ReferenceData\LookupData.ParameterType.sql
:r .\ReferenceData\LookupData.PropertyDataType.sql