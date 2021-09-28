sleep 30s

/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1,1433 -U SA -P "B@zaarDB_123" -i bazaarcore_db_script.sql