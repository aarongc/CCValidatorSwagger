DROP PROCEDURE [dbo].[GetCreditCardInfo]
GO
CREATE PROCEDURE [dbo].[GetCreditCardInfo]
    -- Add the parameters for the stored procedure here
    @CardNumber decimal = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
select *
from CreditCard where CardNumber = @CardNumber
END