<?php
// DATABASE
define('DB_TYPE', 'mysql');
define('DB_HOST', 'studmysql01.fhict.local');
define('DB_NAME', 'dbi437493');
define('DB_USER', 'dbi437493');
define('DB_PASS', 'dbgroup01');
define('DB_CHARSET', 'utf8');
//URL (PROJECT PATH)
define('URL_PUBLIC_FOLDER', 'public');
define('URL_PROTOCOL', '//');
define('URL_DOMAIN', $_SERVER['HTTP_HOST']);
define('URL_SUB_FOLDER', str_replace(URL_PUBLIC_FOLDER, '', dirname($_SERVER['SCRIPT_NAME'])));
define('URL', URL_PROTOCOL . URL_DOMAIN . URL_SUB_FOLDER);