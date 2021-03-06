﻿/*
AspxCommerce® - http://www.aspxcommerce.com
Copyright (c) 20011-2012 by AspxCommerce
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;

namespace AspxCommerce.Core
{
    public class CategoryController
    {
        public CategoryInfo SaveCategory(Int32 storeID, Int32 portalID, Int32 categoryID, Int32 parentID, AspxNameValue[] formVars, string selectedItems, string userName, string culture, int categoryLargeThumbImage, int categoryMediumThumbImage, int categorySmallThumbImage)
        {
            try
            {
                CategoryInfo categoryInfo = new CategoryInfo();
                FormValidation formValidation = new FormValidation();
                List<CategoryAttributeInfo> listCategoryAttributes = new List<CategoryAttributeInfo>();
                categoryInfo.CategoryID = categoryID;
                categoryInfo.ParentID = parentID;
                categoryInfo.IsShowInCatalog = true;
                categoryInfo.IsShowInMenu = true;
                categoryInfo.IsShowInSearch = true;
                categoryInfo.PortalID = portalID;
                categoryInfo.StoreID = storeID;
                categoryInfo.ActiveFrom = new DateTime(1970, 1, 1);
                categoryInfo.ActiveTo = new DateTime(2999, 12, 30);
                bool toInsertIntoDB = true;
                bool isFormValid = true;
                //int _imageCounter = 0;
                string imageVar = string.Empty;
                int imageCounterFirst = 0;

                for (int i = 0; i < formVars.Length; i++)
                {
                    int inputTypeID;
                    int validationTypeID;
                    string attribName = formVars[i].name;
                    string attribValue = formVars[i].value;
                    string jsonResult = formVars[i].name.Replace('-', ' ');
                    string[] jsonVar = jsonResult.Split('_');

                    CategoryAttributeInfo categoryAttribute = new CategoryAttributeInfo();
                    categoryAttribute.AttributeID = int.Parse(jsonVar[0]);
                    inputTypeID = int.Parse(jsonVar[1]);
                    validationTypeID = int.Parse(jsonVar[2]);
                    if (inputTypeID == 1)
                    {
                        if (validationTypeID == 3)
                        {
                            if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                            {
                                categoryAttribute.InputTypeID = inputTypeID;
                                categoryAttribute.ValidationTypeID = validationTypeID;
                                categoryAttribute.DecimalValue = decimal.Parse(attribValue);
                            }
                            else
                            {
                                isFormValid = false;
                                break;
                            }
                        }
                        else if (validationTypeID == 5)
                        {
                            if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                            {
                                categoryAttribute.InputTypeID = inputTypeID;
                                categoryAttribute.ValidationTypeID = validationTypeID;
                                categoryAttribute.IntValue = Int32.Parse(attribValue);
                            }
                            else
                            {
                                isFormValid = false;
                                break;
                            }
                        }
                        else
                        {
                            if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                            {
                                categoryAttribute.InputTypeID = inputTypeID;
                                categoryAttribute.ValidationTypeID = validationTypeID;
                                categoryAttribute.NvarcharValue = attribValue;
                            }
                            else
                            {
                                isFormValid = false;
                                break;
                            }
                        }
                    }
                    else if (inputTypeID == 2)
                    {
                        if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                        {
                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            categoryAttribute.TextValue = attribValue;
                        }
                        else
                        {
                            isFormValid = false;
                            break;
                        }
                    }
                    else if (inputTypeID == 3)
                    {
                        if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                        {
                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            if (!string.IsNullOrEmpty(attribValue))
                            {
                                categoryAttribute.DateValue = DateTime.Parse(attribValue);
                            }
                        }
                        else
                        {
                            isFormValid = false;
                            break;
                        }
                    }
                    else if (inputTypeID == 4)
                    {
                        if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                        {
                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            if (!string.IsNullOrEmpty(attribValue))
                            {
                                categoryAttribute.BooleanValue = (attribValue == "1" ||
                                                                  attribValue.ToLower() == "true")
                                                                     ? true
                                                                     : false;
                            }
                            else
                            {
                                categoryAttribute.BooleanValue = false;
                            }
                        }
                        else
                        {
                            isFormValid = false;
                            break;
                        }
                    }
                    else if (inputTypeID == 5 || inputTypeID == 6 || inputTypeID == 9 || inputTypeID == 10 ||
                             inputTypeID == 11 || inputTypeID == 12)
                    {
                        if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                        {
                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            categoryAttribute.OptionValues = attribValue;
                        }
                        else
                        {
                            isFormValid = false;
                            break;
                        }
                    }
                    else if (inputTypeID == 7)
                    {
                        if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                        {
                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            categoryAttribute.DecimalValue = decimal.Parse(attribValue);
                        }
                        else
                        {
                            isFormValid = false;
                            break;
                        }
                    }
                    else if (inputTypeID == 8)
                    {
                        if (imageCounterFirst % 2 == 0)
                        {
                            toInsertIntoDB = false;
                            if (!string.IsNullOrEmpty(attribValue) && attribValue.ToLower() != "undefined")
                            {
                                if (formValidation.ValidateValue(attribName, validationTypeID, attribValue))
                                {
                                    imageVar = attribValue;
                                }
                                else
                                {

                                    isFormValid = false;
                                    break;
                                }
                            }
                            else
                            {
                                imageVar = "";
                            }
                        }
                        else
                        {
                            toInsertIntoDB = true;

                            categoryAttribute.InputTypeID = inputTypeID;
                            categoryAttribute.ValidationTypeID = validationTypeID;
                            //_imageVar = _imageVar.Replace("../", "");

                            if (attribValue != imageVar)
                            {
                                imageVar = imageVar.Replace("/", "\\");
                                //attribValue = attribValue.Replace("../", "");
                                attribValue = attribValue.Replace("/", "\\");

                                string tempFolder = @"Upload\temp";
                                FileHelperController fileObj = new FileHelperController();
                                attribValue = fileObj.MoveFileToModuleFolder(tempFolder, attribValue, imageVar,categoryLargeThumbImage,categoryMediumThumbImage,categorySmallThumbImage,
                                                                             @"Modules\AspxCommerce\AspxCategoryManagement\uploads\",
                                                                             categoryID, "cat_");
                                categoryAttribute.FileValue = attribValue;
                            }
                            //else if (_imageVar == "")
                            //{
                            //    categoryAttribute.FileValue = _imageVar;
                            //}
                            else
                            {
                                categoryAttribute.FileValue = attribValue;
                            }
                        }
                        imageCounterFirst++;
                    }
                    if (toInsertIntoDB)
                    {
                        listCategoryAttributes.Add(categoryAttribute);
                    }
                }

                if (isFormValid)
                {
                    CategorySqlProvider categorySqlProvider = new CategorySqlProvider();
                    categoryInfo = categorySqlProvider.CategoryAddUpdate(categoryInfo, selectedItems, listCategoryAttributes, userName, culture);
                }
                else
                {
                    throw new Exception("Form is not valid one");
                }
                return categoryInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}