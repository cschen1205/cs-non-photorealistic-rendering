<?php

$uploaddir = './arts/'; // Relative Upload Location of data file
$thumbdir='./art_thumbs/';

if(!file_exists($uploaddir))
{
	mkdir($uploaddir);
}

if(!file_exists($thumbdir))
{
	mkdir($thumbdir);
}

$myDirectory = opendir($uploaddir);

// get each entry
while($entryName = readdir($myDirectory)) 
{
	$dirArray[] = $entryName;
}

// close directory
closedir($myDirectory);

//	count elements in array
$indexCount	= count($dirArray);


// sort 'em
sort($dirArray);

// print 'em
print("<html>");
print("<body bgcolor=\"white\">");
print("<center>");

// loop through the array of files and print them all
$pageIndex=1;
for($index=0; $index < $indexCount; $index++) 
{
	if (substr("$dirArray[$index]", 0, 1) != ".")
	{ 
		$filename = $dirArray[$index];
		$ext = pathinfo($filename, PATHINFO_EXTENSION);
		if(strcmp($ext, 'jpg')==0)
		{
			$fileurl=$uploaddir.$dirArray[$index];
			$thumburl=$thumbdir.$dirArray[$index];
			print("<a href=\"$fileurl\"><img src=\"create_art_thumbnail.php?img=$filename&mw=80&mh=120\" /></a>&nbsp;");
			$pageIndex++;
		}
	}
}

print("</center>");
print("</body>");
print("</html>");



?>