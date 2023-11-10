

/*

exec msdb.dbo.rds_backup_database 
        @source_db_name='DACSOnlineKentico_TEST', 
        @s3_arn_to_backup_to='arn:aws:s3:::dacs-rds-backups/test.dacs.org.uk_20170802.bak',
        @overwrite_S3_backup_file=1;
*/

/*

exec msdb.dbo.rds_backup_database 
        @source_db_name='DACSOnlineKentico_LIVE', 
        @s3_arn_to_backup_to='arn:aws:s3:::dacs-rds-backups/www.dacs.org.uk_20171108.bak',
        @overwrite_S3_backup_file=1;
*/

/*
exec msdb.dbo.rds_backup_database 
        @source_db_name='PART', 
        @s3_arn_to_backup_to='arn:aws:s3:::dacs-rds-backups/PART_20171210_2.bak',
        @overwrite_S3_backup_file=1;

		*/

-- DB RESTORE

/*
exec msdb.dbo.rds_restore_database 
        @restore_db_name='DACSOnlineKentico_TEST_20170910', 
        @s3_arn_to_restore_from='arn:aws:s3:::dacs-rds-backups/www.dacs.org.uk_20170911.bak';
		*/

exec msdb.dbo.rds_task_status @db_name='PART'
exec msdb.dbo.rds_task_status @db_name='DACSOnlineKentico_LIVE'
-- 

--exec msdb.dbo.rds_backup_database 
--        @source_db_name='DACSOnlineKentico_TEST_v2', 
--        @s3_arn_to_backup_to='arn:aws:s3:::dacs-rds-backups/DACSOnlineKentico_TEST_v2-200506.bak',
--        @overwrite_S3_backup_file=1;

		exec msdb.dbo.rds_task_status @db_name='DACSOnlineKentico_TEST_v2'