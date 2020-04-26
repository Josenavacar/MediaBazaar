<?php
	use PHPMailer\PHPMailer\PHPMailer;
	use PHPMailer\PHPMailer\Exception;

	/* Exception class. */
	require(ROOT . "model/PHPMailer/src/Exception.php");
	/* The main PHPMailer class. */
	require (ROOT . "model/PHPMailer/src/PHPMailer.php");
	/* SMTP class, needed if you want to use SMTP. */
	require (ROOT . "model/PHPMailer/src/SMTP.php");

	function sendEmail($adminEmail, $orderID)
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

		   	/* Set the mail sender. */
		   	$mail->setFrom('media_bazaar_nl@hotmail.com', 'Media Bazaar Management', 0);
		   	/* Add a recipient. */
		   	$mail->addAddress($adminEmail, 'Stock Manager');
	  		/* Set the subject. */
		   	$mail->Subject = 'Order confirmation';
		   	/* Set the mail message body. */
		    $mail->Body = "This is your order ID: " . " " . $orderID;
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