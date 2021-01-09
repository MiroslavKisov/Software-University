USE SoftUni

GO
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(50), @Word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @IsComprised BIT = 1;
	DECLARE @Index INT = 1;
	WHILE(@Index <= LEN(@Word))
	BEGIN
		DECLARE @CurrentLetter VARCHAR(1) = SUBSTRING(@Word, @Index, 1); 
		if(@SetOfLetters NOT LIKE '%' + @CurrentLetter + '%')
		BEGIN
			SET @IsComprised = 0;
			BREAK;
		END
	SET @Index += 1;
	END
RETURN @IsComprised;
END