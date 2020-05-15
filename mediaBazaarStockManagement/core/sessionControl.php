<?php 

	/**
	 * Check if the session is longer than 60 seconds, if so then logout
	 */
	if((time() - $_SESSION['loggedin_time']) > 1800) //30 * 60
	{
		// Initialize the session
		session_start();
		 
		// Unset all of the session variables
		session_unset();
		 
		// Destroy the session.
		session_destroy();

		// render("home/login");
		header("Location:" . URL . "login");
		exit();
	}

