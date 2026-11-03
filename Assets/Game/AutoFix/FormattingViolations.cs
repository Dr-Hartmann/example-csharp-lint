#pragma warning disable CS0168
namespace RoslynRulesTest.Assets.Game.AutoFix
{
public sealed class FormattingViolations{
public int Calculate( int left,int right ){if(left>right)return left+right;else{return right-left;}}
public string Join(string first,string second){return first+","+second;}
}
}
#pragma warning restore CS0168
