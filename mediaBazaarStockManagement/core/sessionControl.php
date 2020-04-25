<?php 

	/**
	 * Check if the session is longer than 60 seconds, if so then logout
	 */
	if((time() - $_SESSION['loggedin_time']) > 300) //5 * 60
	{
		// render("home/login");
		header("Location:" . URL . "login");
		exit();
	}

