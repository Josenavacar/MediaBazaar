<?php
	use PHPMailer\PHPMailer\PHPMailer;
	use PHPMailer\PHPMailer\Exception;

	/* Exception class. */
	require(ROOT . "model/PHPMailer/src/Exception.php");
	/* The main PHPMailer class. */
	require (ROOT . "model/PHPMailer/src/PHPMailer.php");
	/* SMTP class, needed if you want to use SMTP. */
	require (ROOT . "model/PHPMailer/src/SMTP.php");

	/**
	 * Method to send email when order is made
	 * @param  [type] $adminEmail [description]
	 * @param  [type] $orderID    [description]
	 * @return [type]             [description]
	 */
	function sendEmail($orderID, $adminEmail)
	{
		$mail = new PHPMailer(TRUE);
		
		try 
		{
			$mail->isSMTP();
			$mail->Username = 'media_bazaar_nl@hotmail.com';
			$mail->Password = 'mediaBazaarNL';
			$mail->SMTPAuth = true;
			$mail->Host = 'smtp.live.com';
			$mail->Port = 587;
			$mail->IsHTML(true);

		   	/* Set the mail sender. */
		   	$mail->setFrom('media_bazaar_nl@hotmail.com', 'Media Bazaar Management', 0);
		   	/* Add a recipient. */
		   	$mail->addAddress($adminEmail, 'Stock Manager');
	  		/* Set the subject. */
		   	$mail->Subject = 'Order confirmation';
		   	/* Set the mail message body. */
		    $mail->Body = 
		    "Your order is confirmed!" . " " .
		    "This is your order ID: " . $orderID . ". " . " " .
		    "<a href='http://localhost/mediabazaar/mediaBazaarStockManagement/order'>Go to orders</a>";

		   	/* Finally send the mail. */
		   	$mail->send();
		}
		catch (Exception $e)
		{
	   		/* PHPMailer exception. */
		   	echo $e->errorMessage();
		}
		catch (\Exception $e)
		{
		   	/* PHP exception (note the backslash to select the global namespace Exception class). */
		   	echo $e->getMessage();
		}
	}

	/**
	 * Method to send login code in email when logging in
	 * @param  [type] $adminEmail [description]
	 * @param  [type] $sessionID  [description]
	 * @return [type]             [description]
	 */
	function sendLoginCode($adminEmail, $sessionID)
	{
		$_SESSION['special_code'] = $sessionID;  

		$mail = new PHPMailer(TRUE);
		
		try 
		{
			$mail->isSMTP();
			$mail->Username = 'media_bazaar_nl@hotmail.com';
			$mail->Password = 'mediaBazaarNL';
			$mail->SMTPAuth = true;
			$mail->Host = 'smtp.live.com';
			$mail->Port = 587;
			$mail->IsHTML(true);

		   	/* Set the mail sender. */
		   	$mail->setFrom('media_bazaar_nl@hotmail.com', 'Media Bazaar Management', 0);
		   	/* Add a recipient. */
		   	$mail->addAddress($adminEmail, 'Stock Manager');
	  		/* Set the subject. */
		   	$mail->Subject = 'Login Code';
		   	/* Set the mail message body. */
		    $mail->Body = 
		    "Please use this code to login. It will expire in one minute. This is your code:" . " " . $sessionID;
		    // "<a href='http://localhost/mediabazaar/mediaBazaarStockManagement/order'>Go to orders</a>";

		   	/* Finally send the mail. */
		   	$mail->send();
		}
		catch (Exception $e)
		{
	   		/* PHPMailer exception. */
		   	echo $e->errorMessage();
		}
		catch (\Exception $e)
		{
		   	/* PHP exception (note the backslash to select the global namespace Exception class). */
		   	echo $e->getMessage();
		}
	}
?>