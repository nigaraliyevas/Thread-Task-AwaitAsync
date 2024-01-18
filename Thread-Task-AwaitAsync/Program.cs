using Thread_Task_AwaitAsync.Helper.Helpers;
UserHelper userHelper = new UserHelper();
var datas = await userHelper.GetDataHttp(d => d.id == 1 || d.id == 10 || d.id == 100);

