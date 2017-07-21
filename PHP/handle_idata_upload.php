<?php

$uploaddir = './arts/';
$uploaddir2 = './art_thumbs/';

$is_raw=$_GET['raw'];
if(strcmp($is_raw, 'yes')==0)
{
	$uploaddir='./images/';
	$uploaddir2='./image_thumbs/';
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