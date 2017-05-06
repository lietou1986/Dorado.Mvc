﻿using Dorado.Components.Extensions;
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Extensions
{
    public class BootstrapExtensionsTests
    {
        private HtmlHelper<BootstrapModel> html;
        private BootstrapModel model;

        public BootstrapExtensionsTests()
        {
            html = HtmlHelperFactory.CreateHtmlHelper(new BootstrapModel());
            model = html.ViewData.Model;
        }

        #region FormLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Boolean? required = null)

        [Fact]
        public void FormLabelFor_OverwrittenNotRequiredExpression()
        {
            String actual = html.FormLabelFor(x => x.Relation.NotRequired, required: true).ToString();
            String expected =
                "<label for=\"Relation_NotRequired\">" +
                    "<span class=\"require\">*</span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_OverwrittenRequiredExpression()
        {
            String actual = html.FormLabelFor(x => x.Relation.Required, required: false).ToString();
            String expected =
                "<label for=\"Relation_Required\">" +
                    "<span class=\"require\"></span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_OverridenRequiredExpression()
        {
            HtmlHelper<BootstrapAdvancedModel> htmlHelper = HtmlHelperFactory.CreateHtmlHelper(new BootstrapAdvancedModel());

            String actual = htmlHelper.FormLabelFor(x => x.NotRequired).ToString();
            String expected =
                "<label for=\"NotRequired\">" +
                    "<span class=\"require\">*</span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_RequiredExpression()
        {
            String actual = html.FormLabelFor(x => x.Relation.Required).ToString();
            String expected =
                "<label for=\"Relation_Required\">" +
                    "<span class=\"require\">*</span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_ValueType()
        {
            String actual = html.FormLabelFor(x => x.Relation.Number).ToString();
            String expected =
                "<label for=\"Relation_Number\">" +
                    "<span class=\"require\">*</span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_NotRequiredExpression()
        {
            String actual = html.FormLabelFor(x => x.Relation.NotRequired).ToString();
            String expected =
                "<label for=\"Relation_NotRequired\">" +
                    "<span class=\"require\"></span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormLabelFor_NullableValueType()
        {
            String actual = html.FormLabelFor(x => x.Relation.Date).ToString();
            String expected =
                "<label for=\"Relation_Date\">" +
                    "<span class=\"require\"></span>" +
                "</label>";

            Assert.Equal(expected, actual);
        }

        #endregion FormLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Boolean? required = null)

        #region FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        [Fact]
        public void FormTextBoxFor_Expression()
        {
            String actual = html.FormTextBoxFor(x => x.Number).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"Number\" name=\"Number\" type=\"text\" value=\"{model.Number}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_EditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableTrue).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableTrue\" name=\"EditableTrue\" type=\"text\" value=\"{model.EditableTrue}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_NotEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        #region FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String format)

        [Fact]
        public void FormTextBoxFor_FormattedEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableTrue, "{0}").ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableTrue\" name=\"EditableTrue\" type=\"text\" value=\"{model.EditableTrue}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_FormattedNotEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse, "{0}").ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_FormattedExpression()
        {
            String actual = html.FormTextBoxFor(x => x.Relation.Number, "{0:0.00}").ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"Relation_Number\" name=\"Relation.Number\" type=\"text\" value=\"{model.Relation.Number:0.00}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String format)

        #region FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        [Fact]
        public void FormTextBoxFor_MergesClassAttributes()
        {
            String actual = html.FormTextBoxFor(x => x.Relation.NotRequired, new { @class = "test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control test\" id=\"Relation_NotRequired\" name=\"Relation.NotRequired\" type=\"text\" value=\"{model.Relation.NotRequired}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_OverwrittenAutocompleteAttribute()
        {
            String actual = html.FormTextBoxFor(x => x.Relation.NotRequired, new { autocomplete = "on" }).ToString();
            String expected = $"<input autocomplete=\"on\" class=\"form-control\" id=\"Relation_NotRequired\" name=\"Relation.NotRequired\" type=\"text\" value=\"{model.Relation.NotRequired}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_OverwrittenReadOnlyAttribute()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse, new { @readonly = "false" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"false\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableTrue, new { data_tab = "Test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" data-tab=\"Test\" id=\"EditableTrue\" name=\"EditableTrue\" type=\"text\" value=\"{model.EditableTrue}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedNotEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse, new { data_tab = "Test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" data-tab=\"Test\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        #region FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String format, Object htmlAttributes)

        [Fact]
        public void FormTextBoxFor_AttributedFormat_MergesClassAttribute()
        {
            String actual = html.FormTextBoxFor(x => x.Relation.Number, "{0:0.00}", new { @class = "test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control test\" id=\"Relation_Number\" name=\"Relation.Number\" type=\"text\" value=\"{model.Relation.Number:0.00}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedFormat_OverwritesAutocompleteAttribute()
        {
            String actual = html.FormTextBoxFor(x => x.Relation.NotRequired, "{0}", new { autocomplete = "on" }).ToString();
            String expected = $"<input autocomplete=\"on\" class=\"form-control\" id=\"Relation_NotRequired\" name=\"Relation.NotRequired\" type=\"text\" value=\"{model.Relation.NotRequired}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedFormat_OverwritesReadOnlyAttribute()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse, "{0}", new { @readonly = "false" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"false\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedFormat_EditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableTrue, "{0}", new { data_tab = "Test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" data-tab=\"Test\" id=\"EditableTrue\" name=\"EditableTrue\" type=\"text\" value=\"{model.EditableTrue}\" />";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextBoxFor_AttributedFormat_NotEditableExpression()
        {
            String actual = html.FormTextBoxFor(x => x.EditableFalse, "{0}", new { data_tab = "Test" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control\" data-tab=\"Test\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" type=\"text\" value=\"{model.EditableFalse}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String format, Object htmlAttributes)

        #region FormPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)

        [Fact]
        public void FormPasswordFor_Expression()
        {
            String expected = "<input autocomplete=\"off\" class=\"form-control\" id=\"Relation_Required\" name=\"Relation.Required\" type=\"password\" />";
            String actual = html.FormPasswordFor(x => x.Relation.Required).ToString();

            Assert.Equal(expected, actual);
        }

        #endregion FormPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)

        #region FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        [Fact]
        public void FormTextAreaFor_Expression()
        {
            String actual = html.FormTextAreaFor(x => x.Number).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control\" cols=\"20\" id=\"Number\" name=\"Number\" rows=\"6\">{Environment.NewLine + model.Number}</textarea>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextAreaFor_EditableExpression()
        {
            String actual = html.FormTextAreaFor(x => x.EditableTrue).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control\" cols=\"20\" id=\"EditableTrue\" name=\"EditableTrue\" rows=\"6\">{Environment.NewLine + model.EditableTrue}</textarea>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextAreaFor_NotEditableExpression()
        {
            String actual = html.FormTextAreaFor(x => x.EditableFalse).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control\" cols=\"20\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" rows=\"6\">{Environment.NewLine + model.EditableFalse}</textarea>";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        #region FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        [Fact]
        public void FormTextAreaFor_AttributedEditableExpression()
        {
            String actual = html.FormTextAreaFor(x => x.EditableTrue, new { @class = "test" }).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control test\" cols=\"20\" id=\"EditableTrue\" name=\"EditableTrue\" rows=\"6\">{Environment.NewLine + model.EditableTrue}</textarea>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextAreaFor_AttributedNotEditableExpression()
        {
            String actual = html.FormTextAreaFor(x => x.EditableFalse, new { @class = "test" }).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control test\" cols=\"20\" id=\"EditableFalse\" name=\"EditableFalse\" readonly=\"readonly\" rows=\"6\">{Environment.NewLine + model.EditableFalse}</textarea>";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormTextAreaFor_OverwrittenRows()
        {
            String actual = html.FormTextAreaFor(x => x.NotRequired, new { rows = "12" }).ToString();
            String expected = $"<textarea autocomplete=\"off\" class=\"form-control\" cols=\"20\" id=\"NotRequired\" name=\"NotRequired\" rows=\"12\">{Environment.NewLine + model.NotRequired}</textarea>";

            Assert.Equal(expected, actual);
        }

        #endregion FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        #region FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        [Fact]
        public void FormDatePickerFor_Expression()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            String actual = html.FormDatePickerFor(x => x.Relation.Date).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control datepicker\" id=\"Relation_Date\" name=\"Relation.Date\" type=\"text\" value=\"{model.Relation.Date:yyyy/MM/dd}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        #region FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        [Fact]
        public void FormDatePickerFor_AttributedExpression()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            String actual = html.FormDatePickerFor(x => x.Relation.Date, new { @readonly = "readonly" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control datepicker\" id=\"Relation_Date\" name=\"Relation.Date\" readonly=\"readonly\" type=\"text\" value=\"{model.Relation.Date:yyyy/MM/dd}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        #region FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        [Fact]
        public void FormDateTimePickerFor_Expression()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            String actual = html.FormDateTimePickerFor(x => x.Relation.Date).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control datetimepicker\" id=\"Relation_Date\" name=\"Relation.Date\" type=\"text\" value=\"{model.Relation.Date:yyyy/MM/dd H:mm}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)

        #region FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)

        [Fact]
        public void FormDateTimePickerFor_AttributedExpression()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            String actual = html.FormDateTimePickerFor(x => x.Relation.Date, new { @readonly = "readonly" }).ToString();
            String expected = $"<input autocomplete=\"off\" class=\"form-control datetimepicker\" id=\"Relation_Date\" name=\"Relation.Date\" readonly=\"readonly\" type=\"text\" value=\"{model.Relation.Date:yyyy/MM/dd H:mm}\" />";

            Assert.Equal(expected, actual);
        }

        #endregion FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes)
    }
}