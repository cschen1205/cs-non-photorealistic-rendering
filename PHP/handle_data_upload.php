<?php

$uploaddir = './images/';
if(isset($_GET['thumb']))
{
	
}

$is_thumb=$_GET['thumb'];
	if(strcmp($is_thumb, 'yes')==0)
	{
		$uploaddir='./image_thumbs/';
	}

if(!file_exists($uploaddir))
{
	mkdir($uploaddir);
}

if (is_uploaded_file($_FILES['file']['tmp_name'])) 
{
	$uploadfile = $uploaddir . $_GET['dst']; //basename($_FILES['file']['name']);

	echo "File ". $_FILES['file']['name'] ."(".$uploaddir.") uploaded successfully. ";

	if (move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)) 
	{
		echo "Upload is valid, and file was successfully uploaded. ";
	}
	else
	{
		print_r($_FILES);
	}
}
else 
{
	echo "Upload Failed!!!";
	print_r($_FILES);
}


?>