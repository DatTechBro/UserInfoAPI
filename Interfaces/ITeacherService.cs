﻿using System.Threading.Tasks;
using UserInfoAPI.Models;
using UserInfoAPI.Services.DTO;
using UserInfoAPI.Services.ViewModels;
using UserInfoAPI.Shared.ViewModels;

namespace UserInfoAPI.Interfaces
{
    public interface ITeacherService
    {
        Task<ResultModel<string>> CreateTeacher(TeacherDTO model);
        List<Teacher> GetAllTeachers();
        Task<ResultModel<TeacherVM>> GetTeacher(int Id);

    }
}
