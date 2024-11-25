
namespace PatrickMuorahProject2
{
    partial class TextTwistMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            letters_lbl = new Label();
            feedback_lbl = new Label();
            timer_lbl = new Label();
            newGame_btn = new Button();
            input_textBox = new TextBox();
            exit_btn = new Button();
            submit_btn = new Button();
            twist_btn = new Button();
            highScore_btn = new Button();
            score_lbl = new Label();
            oneMin_btn = new Button();
            twoMin_btn = new Button();
            threeMin_btn = new Button();
            resetHighScore_btn = new Button();
            SuspendLayout();
            // 
            // letters_lbl
            // 
            letters_lbl.AutoSize = true;
            letters_lbl.Location = new Point(342, 87);
            letters_lbl.Name = "letters_lbl";
            letters_lbl.Size = new Size(90, 15);
            letters_lbl.TabIndex = 0;
            letters_lbl.Text = "Random Letters";
            // 
            // feedback_lbl
            // 
            feedback_lbl.AutoSize = true;
            feedback_lbl.Location = new Point(222, 123);
            feedback_lbl.Name = "feedback_lbl";
            feedback_lbl.Size = new Size(57, 15);
            feedback_lbl.TabIndex = 1;
            feedback_lbl.Text = "Feedback";
            // 
            // timer_lbl
            // 
            timer_lbl.AutoSize = true;
            timer_lbl.Location = new Point(131, 79);
            timer_lbl.Name = "timer_lbl";
            timer_lbl.Size = new Size(37, 15);
            timer_lbl.TabIndex = 2;
            timer_lbl.Text = "Timer";
            // 
            // newGame_btn
            // 
            newGame_btn.Location = new Point(222, 165);
            newGame_btn.Name = "newGame_btn";
            newGame_btn.Size = new Size(75, 23);
            newGame_btn.TabIndex = 3;
            newGame_btn.Text = "New Game";
            newGame_btn.UseVisualStyleBackColor = true;
            newGame_btn.Click += newGame_btn_Click;
            // 
            // input_textBox
            // 
            input_textBox.Location = new Point(204, 79);
            input_textBox.Name = "input_textBox";
            input_textBox.Size = new Size(100, 23);
            input_textBox.TabIndex = 4;
            // 
            // exit_btn
            // 
            exit_btn.Location = new Point(12, 260);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(110, 23);
            exit_btn.TabIndex = 5;
            exit_btn.Text = "Exit";
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // submit_btn
            // 
            submit_btn.Location = new Point(371, 274);
            submit_btn.Name = "submit_btn";
            submit_btn.Size = new Size(75, 23);
            submit_btn.TabIndex = 6;
            submit_btn.Text = "Submit";
            submit_btn.UseVisualStyleBackColor = true;
            submit_btn.Click += submit_btn_Click;
            // 
            // twist_btn
            // 
            twist_btn.Location = new Point(371, 203);
            twist_btn.Name = "twist_btn";
            twist_btn.Size = new Size(75, 23);
            twist_btn.TabIndex = 7;
            twist_btn.Text = "Shuffle";
            twist_btn.UseVisualStyleBackColor = true;
            twist_btn.Click += twist_btn_Click;
            // 
            // highScore_btn
            // 
            highScore_btn.Location = new Point(12, 202);
            highScore_btn.Name = "highScore_btn";
            highScore_btn.Size = new Size(110, 23);
            highScore_btn.TabIndex = 8;
            highScore_btn.Text = "High Score";
            highScore_btn.UseVisualStyleBackColor = true;
            highScore_btn.Click += highScore_btn_Click;
            // 
            // score_lbl
            // 
            score_lbl.AutoSize = true;
            score_lbl.Location = new Point(238, 216);
            score_lbl.Name = "score_lbl";
            score_lbl.Size = new Size(36, 15);
            score_lbl.TabIndex = 9;
            score_lbl.Text = "Score";
            // 
            // oneMin_btn
            // 
            oneMin_btn.Location = new Point(12, 83);
            oneMin_btn.Name = "oneMin_btn";
            oneMin_btn.Size = new Size(94, 23);
            oneMin_btn.TabIndex = 10;
            oneMin_btn.Text = "One Minute";
            oneMin_btn.UseVisualStyleBackColor = true;
            oneMin_btn.Click += oneMin_btn_Click;
            // 
            // twoMin_btn
            // 
            twoMin_btn.Location = new Point(12, 112);
            twoMin_btn.Name = "twoMin_btn";
            twoMin_btn.Size = new Size(94, 23);
            twoMin_btn.TabIndex = 11;
            twoMin_btn.Text = "Two Minutes";
            twoMin_btn.UseVisualStyleBackColor = true;
            twoMin_btn.Click += twoMin_btn_Click;
            // 
            // threeMin_btn
            // 
            threeMin_btn.Location = new Point(12, 141);
            threeMin_btn.Name = "threeMin_btn";
            threeMin_btn.Size = new Size(94, 23);
            threeMin_btn.TabIndex = 12;
            threeMin_btn.Text = "Three Minutes";
            threeMin_btn.UseVisualStyleBackColor = true;
            threeMin_btn.Click += threeMin_btn_Click;
            // 
            // resetHighScore_btn
            // 
            resetHighScore_btn.Location = new Point(12, 231);
            resetHighScore_btn.Name = "resetHighScore_btn";
            resetHighScore_btn.Size = new Size(110, 23);
            resetHighScore_btn.TabIndex = 13;
            resetHighScore_btn.Text = "Reset High Score";
            resetHighScore_btn.UseVisualStyleBackColor = true;
            resetHighScore_btn.Click += resetHighScore_btn_Click;
            // 
            // TextTwistMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 328);
            Controls.Add(resetHighScore_btn);
            Controls.Add(threeMin_btn);
            Controls.Add(twoMin_btn);
            Controls.Add(oneMin_btn);
            Controls.Add(score_lbl);
            Controls.Add(highScore_btn);
            Controls.Add(twist_btn);
            Controls.Add(submit_btn);
            Controls.Add(exit_btn);
            Controls.Add(input_textBox);
            Controls.Add(newGame_btn);
            Controls.Add(timer_lbl);
            Controls.Add(feedback_lbl);
            Controls.Add(letters_lbl);
            Name = "TextTwistMainForm";
            Text = "Text Twist by Muorah";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label letters_lbl;
        private Label feedback_lbl;
        private Label timer_lbl;
        private Button newGame_btn;
        private TextBox input_textBox;
        private Button exit_btn;
        private Button submit_btn;
        private Button twist_btn;
        private Button highScore_btn;
        private Label score_lbl;
        private Button oneMin_btn;
        private Button twoMin_btn;
        private Button threeMin_btn;
        private Button resetHighScore_btn;
    }
}
