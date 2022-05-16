CREATE TABLE [dbo].[UserInfoDetails] (
    [Id]                       UNIQUEIDENTIFIER   NOT NULL,
    [SocialSecurityNumber]     NVARCHAR (MAX)     NOT NULL,
    [Emailaddress]             NVARCHAR (MAX)     NULL,
    [PhoneNumber]              NVARCHAR (MAX)     NULL, 
    [CreatedBy]                NVARCHAR (MAX)     NULL,  
    [UpdatedBy]                NVARCHAR (MAX)     NULL,    
    [CreatedDateTime]          DATETIMEOFFSET (7) NULL,
    [UpdatedDateTime]          DATETIMEOFFSET (7) NULL,
    [Deleted]                  BIT                NOT NULL
     
);


 

