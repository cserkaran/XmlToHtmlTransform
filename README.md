# XmlToHtmlTransform
An XmlToHtml transform application for bulk number of xml files using two threads,
 one to read from xml and other to write the xml contents to html.

Problem Description

Build an application with 2 threads:

The first thread will read sequentially through the attached XML files, from \Data\Computers, and place their contents on an internal queue.
 
A separate consumer thread will run concurrently with the first thread and will read from the internal queue, and render the XML to HTML in directory Data\Output using stylesheet “Computers.xsl” provided. Filename of rendered output can be any unique value.



Nice to haves:

·         Implement Dependency injection design pattern in your code.
·         Unit Testing
·         Mocking framework

