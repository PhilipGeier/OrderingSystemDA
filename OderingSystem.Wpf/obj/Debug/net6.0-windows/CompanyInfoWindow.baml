   M S B A M L   `   `   `  ????L  HOderingSystem.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:OderingSystem.WpfOderingSystem.Wpf  5   	   )    #OderingSystem.Wpf.CompanyInfoWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:OderingSystem.Wpf     5   	     ? Title$  CompanyInfoWindow??5   	   $	??200??6#   $	??300??60   .??5	      ?? .+?5
   
   ?? $??Company Info??6    ?? TextAlignment$ Center=?6(   $
??0,10q?6?   $??20(?6M   $
??Bold"?6[   ? 5   
    ? RowDefinitions 5      ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6     ? ColumnDefinitions 5      ?? 5      $??70 ?6#   ?? 5      $??* ?6#   .+?5      ?? $	??ID:??6   $
??Bold"?6#   ?? 5      $??Name:??6   $
??Bold"?6%   $??1??67   ?? 5      $??Street:??6   $
??Bold"?6'   $??2??69   ?? 5      $??Zipcode:??6   $
??Bold"?6(   $??3??6:   ?? 5      $??City:??6   $
??Bold"?6%   $??4??67   ?? 5       $
??UID:??6   $
??Bold"?6$   $??5??66   ?? 5!      $??
Telephone:??6   $
??Bold"?6*   $??6??6<   ?? 5#      -   5         ??Name$ IDField??5#      $??1??6)   ?? 5$      -   5        $ 	NameField??5$      $??1??6+   $??1??6;   ?? 5%      -   5        $ StreetField??5%      $??1??6-   $??2??6=   ?? 5&      -   5        $ ZipField??5&      $??1??6*   $??3??6:   ?? 5'      -   5        $ 	CityField??5'      $??1??6+   $??4??6;   ?? 5(      -   5        $ UIDField??5(      $??1??6*   $??5??6:   ?? 5)      -   5        $ TelField??5)      $??1??6*   $??6??6:   5*      5+      5,      