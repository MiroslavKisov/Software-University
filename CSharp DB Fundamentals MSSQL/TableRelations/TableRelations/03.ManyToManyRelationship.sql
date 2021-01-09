USE TableRelations


CREATE TABLE Students(
	StudentID INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
)

INSERT INTO Students(StudentID, Name)
     VALUES
	 (1, 'Mila'),
	 (2, 'Toni'),
	 (3, 'Ron')

--ALTER TABLE

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
)

INSERT INTO Exams(ExamID, Name)
     VALUES
	 (101, 'SpringMVC'),
	 (102, 'Neo4j'),
	 (103, 'Oracle 11g')

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,

	CONSTRAINT PK_Students_Exams
	PRIMARY KEY(StudentID, ExamID),

	CONSTRAINT FK_StudentsID
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_ExamsID
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams (StudentID, ExamID)
     VALUES
	 (1, 101),
	 (1, 102),
	 (2, 101),
	 (3, 103),
	 (2, 102),
	 (2, 103)
