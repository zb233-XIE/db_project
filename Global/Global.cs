using TJ_Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games
{
  public static class Global
  {
    public static string GSearchName = "";
    //��ֵ�趨Ϊdebug����
    //�������ڵ�����

    public static List<string> GClassification = new List<string> { "���" };
    //��ֵ�趨Ϊdebug����
    //����ҳ�����������������ת������ҳ�棬����ҳ�����ṩһЩѡ������С��Χ
    //������Ϸ���ͣ������steam��

    public static Cart GCart;
    //���ﳵ���ύ������ȷ��ҳ�����Ʒ

    public static string GToWhom;
    // 1:Ϊ�Լ�����  2:Ϊ���˹���
  }
}
