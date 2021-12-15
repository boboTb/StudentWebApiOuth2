using Models.Model;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL
{
    public class StudentBusiness:IDisposable
    {
        IDbConnection _connection = null;
        public StudentBusiness(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }
        public void Dispose()
        {

        }
        public async Task<List<Student>> GetAllStudents()
        {
           
            try
            {
                using (StudentRepository studentRepostory = new StudentRepository(_connection))
                {
                    return await studentRepostory.GetAllStudents();
                }
            }
            catch(Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
        public async Task<int> InsertStudent(Student student)
        {

            try
            {
                using (StudentRepository studentRepostory = new StudentRepository(_connection))
                {
                    student.Student_ID = await studentRepostory.InsertStudent(student);
                }
                using (KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    await kursStudentRepository.ReplaceCourses(student.Kursevi, student.Student_ID);
                }
                return student.Student_ID;
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return 0;
            }
        }
        public async Task UpdateStudent(Student student)
        {

            try
            {
                using(KursStudentRepository kursStudentRepository = new KursStudentRepository(_connection))
                {
                    await kursStudentRepository.ReplaceCourses(student.Kursevi, student.Student_ID);
                }
                using (StudentRepository studentRepostory = new StudentRepository(_connection))
                {
                    await studentRepostory.UpdateStudent(student);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }
        public async Task DeleteStudent(int id)
        {

            try
            {
                using (StudentRepository studentRepostory = new StudentRepository(_connection))
                {
                    await studentRepostory.DeleteStudent(id);
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
        }

        public async Task<List<Student>> ReadStudentProcedure()
        {

            try
            {
                using (StudentRepository studentRepostory = new StudentRepository(_connection))
                {
                    return await studentRepostory.ReadStudentProcedure();
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                return null;
            }
        }
    }
}
