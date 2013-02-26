CREATE PROCEDURE [LogicData].[GetCommandAction](
												@CommandTypeId int, 
												@FirstParameterId uniqueidentifier = NULL, 
												@SecondParameterId uniqueidentifier = NULL, 
												@ThirdParameterId uniqueidentifier = NULL, 
												@FourthParameterId uniqueidentifier = NULL, 
												@GameId uniqueidentifier = NULL) AS

SELECT CA.*
FROM [LogicData].[CommandAction] CA
INNER JOIN [LogicData].[Command] C on C.CommandID = CA.CommandID
WHERE C.CommandTypeID = @CommandTypeId
AND (@FirstParameterId IS NULL OR CA.FirstParameterID = @FirstParameterId)
AND (@SecondParameterId IS NULL OR CA.SecondParameterID = @SecondParameterId)
AND (@ThirdParameterId IS NULL OR CA.ThirdParameterID = @ThirdParameterId)
AND (@ThirdParameterId IS NULL OR CA.FourthParameterID = @FourthParameterId)
AND (@GameId IS NULL OR CA.GameID = @GameId)


