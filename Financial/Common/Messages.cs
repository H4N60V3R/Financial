﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Common
{
    public class Messages
    {
        #region Common

        public static string NotSet = "ثبت نشده";

        #endregion

        #region Account

        public static string CreateAccountSuccessful = "حساب جدید با موفقیت ثبت شد";
        public static string CreateAccountFailed = "حساب جدید با موفقیت ثبت نشد";

        public static string EditAccountSuccessful = "حساب مورد نظر با موفقیت ویرایش شد";
        public static string EditAccountFailed = "حساب مورد نظر با موفقیت ویرایش نشد";

        public static string DeleteAccountText = "آیا از حذف حساب مورد نظر اطمینان دارید؟";
        public static string DeleteAccountSuccessful = "حساب مورد نظر با موفقیت حذف شد";
        public static string DeleteAccountFailed = "حساب مورد نظر با موفقیت حذف نشد";

        #endregion

        #region Transaction

        public static string CreateTransactionSuccessful = "تراکنش جدید با موفقیت ثبت شد";
        public static string CreateTransactionFailed = "تراکنش جدید با موفقیت ثبت نشد";

        public static string EditTransactionSuccessful = "تراکنش مورد نظر با موفقیت ویرایش شد";
        public static string EditTransactionFailed = "تراکنش مورد نظر با موفقیت ویرایش نشد";

        public static string DeleteTransactionText = "آیا از حذف تراکنش مورد نظر اطمینان دارید؟";
        public static string DeleteTransactionSuccessful = "تراکنش مورد نظر با موفقیت حذف شد";
        public static string DeleteTransactionFailed = "تراکنش مورد نظر با موفقیت حذف نشد";

        #endregion
    }
}