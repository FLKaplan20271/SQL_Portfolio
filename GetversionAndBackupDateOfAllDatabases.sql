select sysdatabases.name, Convert(date,crdate) as 'Create Date', 

(Select  

CASE  

WHEN cmptlevel = '100' then 'SQL Server 2008'  

 WHEN cmptlevel= '110' then 'SQL Server 2012'  

 WHEN cmptlevel = '120' then 'SQL Server 2014'  

 WHEN cmptlevel = '130' then 'SQL Server 2016'  

 end) as 'SQL Server Version', 

 COALESCE(CONVERT(VARCHAR(12), MAX(bus.backup_finish_date), 101),'-') AS LastBackUpDate 

from sys.sysdatabases  

left outer join msdb.dbo.backupset bus ON bus.database_name = sys.sysdatabases.name 

where dbid >6 group by sysdatabases.name,sysdatabases.crdate, sysdatabases.cmptlevel order by name asc 