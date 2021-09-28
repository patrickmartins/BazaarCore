FROM mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04

RUN mkdir -p /usr/scripts
WORKDIR /usr/scripts
COPY . /usr/scripts

EXPOSE 1433

ENTRYPOINT [ "/bin/bash", "./execute-sql-service.sh" ]