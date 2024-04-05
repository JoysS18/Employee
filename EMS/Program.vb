Imports System

Public Class Employee
    Public Property Name As String
    Public Property ID As String
    Public Property Department As String
    Public Property Salary As Double

    Public Sub New(ByVal name As String, ByVal id As String, ByVal department As String, ByVal salary As Double)
        Me.Name = name
        Me.ID = id
        Me.Department = department
        Me.Salary = salary
    End Sub
End Class

Public Class EmployeeManagementSystem
        Private employees As New List(Of Employee)

    Public Sub AddEmployee()
        Console.WriteLine("Enter employee name: ")
        Dim name As String = Console.ReadLine()
        Console.WriteLine("Enter employee ID: ")
        Dim id As String = Console.ReadLine()
        Console.WriteLine("Enter employee department: ")
        Dim department As String = Console.ReadLine()
        Console.WriteLine("Enter employee salary: ")
        Dim salary As Double = Convert.ToDouble(Console.ReadLine())
        Dim employee As New Employee(name, id, department, salary)
        employees.Add(employee)
        Console.WriteLine("Employee added successfully!")
    End Sub

    Public Sub DeleteEmployee()
        Console.WriteLine("Enter employee ID to delete: ")
        Dim idToDelete As String = Console.ReadLine()
        Dim found As Boolean = False
        For Each emp As Employee In employees
            If emp.ID = idToDelete Then
                employees.Remove(emp)
                Console.WriteLine("Employee deleted successfully!")
                found = True
                Exit For
            End If
        Next
        If Not found Then
            Console.WriteLine("Employee not found!")
        End If
    End Sub
    Public Sub ModifyEmployee()
        Console.WriteLine("Enter employee ID to modify: ")
        Dim idToModify As String = Console.ReadLine()
        Dim found As Boolean = False
        For Each emp As Employee In employees
            If emp.ID = idToModify Then
                Console.WriteLine("1. Modify Name")
                Console.WriteLine("2. Modify Department")
                Console.WriteLine("3. Modify Salary")
                Dim choice As String = Console.ReadLine()
                Select Case choice
                    Case "1"
                        Console.WriteLine("Enter new name: ")
                        emp.Name = Console.ReadLine()
                    Case "2"
                        Console.WriteLine("Enter new department: ")
                        emp.Department = Console.ReadLine()
                    Case "3"
                        Console.WriteLine("Enter new salary: ")
                        emp.Salary = Convert.ToDouble(Console.ReadLine())
                    Case Else
                        Console.WriteLine("Invalid choice!")
                End Select
                Console.WriteLine("Employee modified successfully!")
                found = True
                Exit For
            End If
        Next
        If Not found Then
            Console.WriteLine("Employee not found!")
        End If
    End Sub
    Public Sub DisplayEmployees()
        Console.WriteLine("All Employees:")
        For Each emp As Employee In employees
            Console.WriteLine("Name: " & emp.Name)
            Console.WriteLine("ID: " & emp.ID)
            Console.WriteLine("Department: " & emp.Department)
            Console.WriteLine("Salary: " & emp.Salary)
            Console.WriteLine("-----------------------")
        Next
    End Sub
End Class

Module Program
    Sub Main()
        Dim empManagementSystem As New EmployeeManagementSystem()

        For i As Integer = 1 To 3
            empManagementSystem.AddEmployee()
        Next

        While True
            Console.WriteLine(vbCrLf & "Employee Management System Menu:")
            Console.WriteLine("1. Add Employee")
            Console.WriteLine("2. Delete Employee")
            Console.WriteLine("3. Modify Employee")
            Console.WriteLine("4. Display All Employees")
            Console.WriteLine("5. Exit")

            Console.WriteLine("Enter your choice: ")
            Dim choice As String = Console.ReadLine()

            Select Case choice
                Case "1"
                    empManagementSystem.AddEmployee()
                Case "2"
                    empManagementSystem.DeleteEmployee()
                Case "3"
                    empManagementSystem.ModifyEmployee()
                Case "4"
                    empManagementSystem.DisplayEmployees()
                Case "5"
                    Console.WriteLine("Exiting...")
                    Exit While
                Case Else
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.")
            End Select
        End While
    End Sub
End Module
