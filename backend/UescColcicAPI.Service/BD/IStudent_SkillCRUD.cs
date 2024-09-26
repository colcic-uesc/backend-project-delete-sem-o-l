using System;
using UescColcicAPI.Core;

using UescColcicAPI.Services.BD.Interfaces;

public interface IStudent_SkillCRUD : IBaseCRUD<Student_Skill>
{
    object Find(int studentId, int skillId);
}
