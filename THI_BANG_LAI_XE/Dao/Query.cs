using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.Dao;

namespace THI_BANG_LAI_XE.Dao
{
    public class Query
    {
        private readonly ThiBangLaiXeContext _context;
        public Query(ThiBangLaiXeContext context)
        {
            _context = context;
            _answerDao = new Lazy<AnswerDao>(() => new AnswerDao(_context));
            _courseDao = new Lazy<CourseDao>(() => new CourseDao(_context));
            _examDao = new Lazy<ExamDao>(() => new ExamDao(_context));
            _examPaperDao = new Lazy<ExamPaperDao>(() => new ExamPaperDao(_context));
            _questionDao = new Lazy<QuestionDao>(() => new QuestionDao(_context));
            _registrationDao = new Lazy<RegistrationDao>(() => new RegistrationDao(_context));
            _userDao = new Lazy<UserDao>(() => new UserDao(_context));
            _result = new Lazy<ResultDao>(() => new ResultDao(_context));
            _userSelectAnswerDao = new Lazy<UserSelectAnswerDao>(() => new UserSelectAnswerDao(_context));
            _certificateDao = new Lazy<CertificateDao>(() => new CertificateDao(_context));
            _notificationDao = new Lazy<NotificationDao>(() => new NotificationDao(_context));

        }

        private Lazy<AnswerDao> _answerDao;
        private Lazy<CourseDao> _courseDao;
        private Lazy<ExamDao> _examDao;
        private Lazy<ExamPaperDao> _examPaperDao;
        private Lazy<QuestionDao> _questionDao;
        private Lazy<RegistrationDao> _registrationDao;
        private Lazy<UserDao> _userDao;
        private Lazy<ResultDao> _result;
        private Lazy<UserSelectAnswerDao> _userSelectAnswerDao;
        private Lazy<CertificateDao> _certificateDao;
        private Lazy<NotificationDao> _notificationDao;


        public AnswerDao answerDao => _answerDao.Value;
        public CourseDao courseDao => _courseDao.Value;
        public ExamDao examDao => _examDao.Value;
        public ExamPaperDao examPaperDao => _examPaperDao.Value;
        public QuestionDao questionDao => _questionDao.Value;
        public RegistrationDao registrationDao => _registrationDao.Value;
        public UserDao userDao => _userDao.Value;
        public ResultDao resultDao => _result.Value;
        public UserSelectAnswerDao userSelectAnswerDao => _userSelectAnswerDao.Value;
        public CertificateDao certificateDao => _certificateDao.Value;
        public NotificationDao notificationDao => _notificationDao.Value;
    }

}
