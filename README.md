# Building an AWS IAM & S3 Management Application
### Tools and Technologies
<div style="display: inline-block">
    <img title="C#" width="30px" style="padding-right:10px;" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg">
    <img title="AWS: IAM, S3" width="40px" style="padding-right:10px;" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/amazonwebservices/amazonwebservices-plain-wordmark.svg">
</div>

## Introduction
In January 2024, as part of an academic lab assignment, I developed a C# application designed to interact with Amazon Web Services (AWS) S3 (Simple Storage Service) and IAM (Identity and Access Management) services. This case study outlines the objectives, implementation, and outcomes of the project.

## Objective
The primary goal of this project was to create a WPF (Windows Presentation Foundation) application that enables users to manage AWS S3 buckets and perform object-level operations such as uploading and deleting objects. The application needed to provide a user-friendly interface for interacting with AWS services programmatically.

## Implementation:

### User Interface Design
- The application featured a main window with buttons for accessing different functionalities: creating buckets and performing object-level operations.
- Separate windows were designed to facilitate bucket creation and object-level operations.
- Proper navigation between windows was ensured for a seamless user experience.

### Create Bucket Functionality
- Implemented functionality to retrieve all existing buckets under the user's profile.
- Displayed the list of buckets in a DataGrid for easy reference.
- Provided a window for creating new buckets where users could input the bucket name.
- Upon creating a new bucket, it was dynamically added to the list of buckets displayed in the DataGrid.

### Object Level Operation Functionality
- Listed all buckets in a ComboBox for selection by the user.
- Retrieved and displayed all objects existing in the selected bucket in a DataGrid.
- Enabled users to upload selected objects to the chosen bucket by browsing and selecting files.
- Upon successful upload, the newly uploaded objects were immediately reflected in the DataGrid.

### Overall Design
- Emphasized readability and maintainability of the codebase.
- Ensured proper documentation and commented code for future reference and collaboration.
- Adhered to best practices in C# application development for robustness and scalability.

## Outcome
The developed application successfully met the objectives outlined in the lab assignment. It provided a user-friendly interface for managing AWS S3 buckets and performing object-level operations. Through this project, I gained hands-on experience with AWS services, C# programming, and WPF application development.

## Conclusion
This case study demonstrates my ability to implement practical solutions for real-world challenges using cloud services and programming languages. The project showcased my proficiency in AWS S3, IAM, and C# development, highlighting my capacity to deliver effective solutions in a professional setting.




# Screenshots of Solution

## Main Window
![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/748b5ca1-cf20-46f6-8f7a-48f37cd22a1d)

*Main window to facilitate navigation to bucket creation and object level operations windows*

## Create Bucket Window
![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/6b4fe885-1688-4f20-a662-b81021f52f65)

*Error message displayed when the user tries to enter a bucket name with uppercase character(s) or with whitespace(s)*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/b65ddda0-3270-4021-9f98-7add288119b5)

*Bucket created successfully with correct naming convention.*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/07beffb4-5143-492b-957c-ae4f44a93f09)

*Window pop up letting the user know the bucket was created successfully.*

## Object Level Operation Window
![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/751abc6b-ed3e-4395-9ce5-68bc6828027b)

*Buckets that were previously created now listed in the combobox*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/1d8eeee6-6d1b-4d1c-b2de-2b3f06642441)

*Showing the objects in a previously created bucket*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/a62081cf-316c-4f85-b649-f6950345083c)

*Uploading a text file object to our newly created bucket*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/029356ae-7ba1-428a-a97b-49d97f2acf27)

*Once the file got selected the file path is copied to the Object text box in the window*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/4640cdbf-d0c1-4418-8f12-06e0515df178)

*Once the user clicks the “Upload” button, a window pops up confirming to the user that the object was uploaded successfully.*

![image](https://github.com/TariqueJemison01/aws-iam-s3-service/assets/119014013/9ad700a8-fb0d-42e9-83c3-0d268d4378d0)

*The bucket now has the object listed in the data grid.*
