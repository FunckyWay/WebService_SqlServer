# WebService_SqlServer
一个为Xamarin提供数据的WebService接口  
1.修改Web.Config文件中的`  <connectionStrings>
    <add name="ConStr" connectionString="Data Source=.;Initial Catalog=Demo;Integrated Security=False;User Id = sa;Password = 6684855;"/>
  </connectionStrings>`里面的数据库配置信息  
 2..asmx.cs文件就是你的WebService的方法目录  
 3.SqlHelper文件主要是数据库链接模块  
 4.Dealer.cs文件就是你的方法具体实现
