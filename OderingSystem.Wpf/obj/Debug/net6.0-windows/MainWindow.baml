   M S B A M L   `   `   `  ????L  HOderingSystem.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:OderingSystem.WpfOderingSystem.Wpf  5   	   "    OderingSystem.Wpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:OderingSystem.Wpf     5   	   
???????  ? Title$  
MainWindow??5	   	   $
??1080??6   $
??1920??6*   .??5
      ? -   5         ?Name$ MainWindowGrid??5
       ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $	??190 ?6   .+?5   
   ?? 
???????$??2q?6$   $??1??68   $??1??6E   ._?5      ?? .+?5      ?? -   5         ??Name$ ItemTransferButton??5      $??40??5      $??Transfer Items??5      $??2q?5      ?? 5      -   5        $ 
SwitchView??5      $??Switch Table View??5      $??2q?5      $??40??6$   ?? 5       -   5        $ ShowCompanyInfo??5       $??Show Company Info??5!      $??2q?5#      $??40??6$   ?? 5$      -   5        $ OpenManagementArea??5$      $??Open Management Area??5%      $??2q?5'      $??40??6$   5(      5)      ?? 5+   
   $??Ordering-System??5,      $??35(?5-      $
??Bold"?5.      ?? 50   
   $??0??51      $??1??52      $??
Navigation??53      $??35(?54      $
??Bold"?55      ?? 57   
   
???????$??2q?6$   $??1??68   ._?58       ? -   5          ?Name$
 Main??59        ? NavigationUIVisibility$ Hidden=?5:      $??1??5;      5<      5=      5>      